const localeFallback: Record<string, string> = {
  'zh-Hans': 'zh-CN',
  'zh-cn': 'zh-CN',
  ja: 'ja-JP',
}

export function formatLocalDateTime(iso: string, locale: string): string {
  const date = new Date(iso)
  if (Number.isNaN(date.getTime())) {
    return iso
  }

  const resolved = localeFallback[locale] ?? locale
  try {
    return new Intl.DateTimeFormat(resolved, {
      dateStyle: 'medium',
      timeStyle: 'short',
      timeZoneName: 'short',
    }).format(date)
  } catch {
    return date.toISOString()
  }
}
