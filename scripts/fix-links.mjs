#!/usr/bin/env node
import fs from 'node:fs'
import path from 'node:path'

const docsRoot = path.resolve(import.meta.dirname, '../docs')

function detectLocale(rel) {
  if (rel.startsWith('zh-cn/')) return 'zh-cn'
  if (rel.startsWith('ja/')) return 'ja'
  return 'en'
}

function prefix(locale) {
  if (locale === 'zh-cn') return '/zh-cn'
  if (locale === 'ja') return '/ja'
  return ''
}

function walk(dir, files = []) {
  for (const entry of fs.readdirSync(dir, { withFileTypes: true })) {
    const full = path.join(dir, entry.name)
    if (entry.isDirectory()) walk(full, files)
    else if (entry.name.endsWith('.md')) files.push(full)
  }
  return files
}

for (const file of walk(docsRoot)) {
  const rel = path.relative(docsRoot, file).replace(/\\/g, '/')
  const locale = detectLocale(rel)
  const p = prefix(locale)
  let content = fs.readFileSync(file, 'utf-8')
  const before = content

  content = content.replace(/\]\(\.\.\/?\)/g, `](${p || '/'})`)
  content = content.replace(/\]\(\.\.\/([^)]+)\)/g, (_, target) => {
    const abs = `${p}/${target}`.replace(/\/+/g, '/')
    return `](${abs})`
  })

  content = content.replace(
    /\]\((\/(?:zh-cn|ja)?\/?generators)\)/g,
    ']($1/)',
  )

  content = content.replace(
    /\*\*http:\/\/localhost:5173\/Prism\.SourceGenerators\.Docs\/\*\*/g,
    '`http://localhost:5173/Prism.SourceGenerators.Docs/`',
  )

  if (content !== before) {
    fs.writeFileSync(file, content, 'utf-8')
    console.log('Fixed links:', rel)
  }
}

console.log('Done.')
