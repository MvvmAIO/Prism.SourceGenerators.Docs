export interface SiteMeta {
  /** ISO 8601 timestamp of the latest commit (site deploy revision). */
  lastUpdated: string
  commitSha: string
  shortSha: string
}

const docsRepo = 'https://github.com/MvvmAIO/Prism.SourceGenerators.Docs'

export function commitUrl(sha: string): string {
  return sha ? `${docsRepo}/commit/${sha}` : docsRepo
}

declare const __SITE_META__: SiteMeta

/** Injected at build time from the latest git commit (see config.mts). */
export const siteMeta: SiteMeta = __SITE_META__
