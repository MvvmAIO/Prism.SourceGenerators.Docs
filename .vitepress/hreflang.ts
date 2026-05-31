import fs from 'node:fs'
import path from 'node:path'
import type { PageData } from 'vitepress'

const SITE_HOST = 'https://mvvmaio.github.io/Prism.SourceGenerators.Docs'

type LocaleId = 'root' | 'zh-cn' | 'ja'

const HREFLANG: Record<LocaleId, string> = {
  root: 'en',
  'zh-cn': 'zh-Hans',
  ja: 'ja',
}

/** content-key (e.g. getting-started.md) -> locales that have the page */
let registry: Map<string, Set<LocaleId>> | undefined

function stripLocalePrefix(relativePath: string): string {
  const p = relativePath.replace(/\\/g, '/')
  if (p.startsWith('zh-cn/')) return p.slice(6)
  if (p.startsWith('ja/')) return p.slice(3)
  return p
}

function localeFromPath(relativePath: string): LocaleId {
  const p = relativePath.replace(/\\/g, '/')
  if (p.startsWith('zh-cn/')) return 'zh-cn'
  if (p.startsWith('ja/')) return 'ja'
  return 'root'
}

function buildRegistry(docsRoot: string): Map<string, Set<LocaleId>> {
  const map = new Map<string, Set<LocaleId>>()

  function add(locale: LocaleId, contentKey: string) {
    let set = map.get(contentKey)
    if (!set) {
      set = new Set()
      map.set(contentKey, set)
    }
    set.add(locale)
  }

  for (const file of fs.readdirSync(docsRoot, { recursive: true })) {
    if (typeof file !== 'string' || !file.endsWith('.md')) continue
    const rel = file.replace(/\\/g, '/')
    add(localeFromPath(rel), stripLocalePrefix(rel))
  }

  return map
}

function toServedPath(locale: LocaleId, contentKey: string): string {
  const stem = contentKey.replace(/\.md$/i, '')
  const lastSlash = stem.lastIndexOf('/')
  const fileName = lastSlash >= 0 ? stem.slice(lastSlash + 1) : stem
  let pathPart: string
  if (fileName.toLowerCase() === 'index') {
    const dir = lastSlash >= 0 ? stem.slice(0, lastSlash) : ''
    pathPart = dir ? `/${dir}/` : '/'
  } else {
    pathPart = `/${stem}/`
  }

  if (locale === 'zh-cn') {
    return pathPart === '/' ? '/zh-cn/' : `/zh-cn${pathPart}`
  }
  if (locale === 'ja') {
    return pathPart === '/' ? '/ja/' : `/ja${pathPart}`
  }
  return pathPart
}

export function ensureHreflangRegistry(docsRoot: string): void {
  if (!registry) {
    registry = buildRegistry(docsRoot)
  }
}

export function injectHreflang(pageData: PageData, docsRoot: string): void {
  ensureHreflangRegistry(docsRoot)

  const relativePath = pageData.relativePath.replace(/\\/g, '/')
  const contentKey = stripLocalePrefix(relativePath)
  const currentLocale = localeFromPath(relativePath)
  const canonical = `${SITE_HOST}${toServedPath(currentLocale, contentKey)}`

  pageData.frontmatter.head ??= []
  pageData.frontmatter.head.push(
    ['link', { rel: 'canonical', href: canonical }],
  )

  const existing = registry!.get(contentKey)
  if (!existing) return

  for (const locale of existing) {
    pageData.frontmatter.head.push([
      'link',
      {
        rel: 'alternate',
        hreflang: HREFLANG[locale],
        href: `${SITE_HOST}${toServedPath(locale, contentKey)}`,
      },
    ])
  }

  if (existing.has('root')) {
    pageData.frontmatter.head.push([
      'link',
      {
        rel: 'alternate',
        hreflang: 'x-default',
        href: `${SITE_HOST}${toServedPath('root', contentKey)}`,
      },
    ])
  }
}
