#!/usr/bin/env node
/** Fix frontmatter order: YAML must precede body (migration inserted tips before frontmatter on CRLF files). */
import fs from 'node:fs'
import path from 'node:path'

const docsRoot = path.resolve(import.meta.dirname, '../docs')

const enHome = fs.readFileSync(
  path.join(import.meta.dirname, 'home-index-en.md'),
  'utf-8',
)

function walk(dir, files = []) {
  for (const entry of fs.readdirSync(dir, { withFileTypes: true })) {
    const full = path.join(dir, entry.name)
    if (entry.isDirectory()) walk(full, files)
    else if (entry.name.endsWith('.md')) files.push(full)
  }
  return files
}

function normalize(content) {
  const normalized = content.replace(/\r\n/g, '\n')

  const tipFirst = normalized.match(
    /^(::: tip[\s\S]*?\n:::\n+)---\n([\s\S]*?\n)---\n/,
  )
  if (tipFirst) {
    const tip = tipFirst[1]
    const fm = `---\n${tipFirst[2]}---\n`
    const body = normalized.slice(tipFirst[0].length)
    return fm + tip + body
  }

  const fmMatch = normalized.match(/^---\n([\s\S]*?)\n---\n/)
  if (!fmMatch) return normalized

  const fm = fmMatch[0]
  let body = normalized.slice(fm.length)

  const tipMatch = body.match(/^::: tip[\s\S]*?\n:::\n\n/)
  if (tipMatch) {
    body = body.slice(tipMatch[0].length)
    return fm + tipMatch[0] + body
  }

  return normalized
}

for (const file of walk(docsRoot)) {
  const rel = path.relative(docsRoot, file).replace(/\\/g, '/')
  if (rel === 'index.md') {
    fs.writeFileSync(file, enHome, 'utf-8')
    console.log('Fixed home:', rel)
    continue
  }

  const raw = fs.readFileSync(file, 'utf-8')
  const fixed = normalize(raw)
  if (fixed !== raw.replace(/\r\n/g, '\n')) {
    fs.writeFileSync(file, fixed, 'utf-8')
    console.log('Fixed order:', rel)
  }
}

console.log('Done.')
