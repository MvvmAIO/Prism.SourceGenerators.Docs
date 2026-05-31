<script setup lang="ts">
import { computed, onMounted, onUnmounted, ref, watch } from 'vue'
import { useData } from 'vitepress'
import { commitUrl, siteMeta } from '../site-meta.shared'
import { formatLocalDateTime, siteFallbackLocale } from './format-local-datetime'

const { theme, frontmatter, lang } = useData()

const footerRef = ref<HTMLElement | null>(null)
let resizeObserver: ResizeObserver | undefined

function syncFooterOffset() {
  const height = footerRef.value?.offsetHeight ?? 0
  document.documentElement.style.setProperty(
    '--vp-site-footer-offset',
    `${height}px`,
  )
}

function clearFooterOffset() {
  document.documentElement.style.removeProperty('--vp-site-footer-offset')
}

function refreshFormattedDate() {
  formattedSiteUpdated.value = formatLocalDateTime(
    siteMeta.lastUpdated,
    siteFallbackLocale(lang.value),
  )
}

onMounted(() => {
  refreshFormattedDate()
  syncFooterOffset()
  resizeObserver = new ResizeObserver(syncFooterOffset)
  if (footerRef.value) resizeObserver.observe(footerRef.value)
})

onUnmounted(() => {
  resizeObserver?.disconnect()
  clearFooterOffset()
})

watch(
  () => frontmatter.value.footer,
  (show) => {
    if (show === false) clearFooterOffset()
    else syncFooterOffset()
  },
)

const isZh = computed(
  () => lang.value === 'zh-Hans' || lang.value === 'zh-cn',
)
const isJa = computed(() => lang.value === 'ja')

const formattedSiteUpdated = ref(
  formatLocalDateTime(siteMeta.lastUpdated, siteFallbackLocale(lang.value)),
)

const buildLink = computed(() => commitUrl(siteMeta.commitSha))
</script>

<template>
  <footer
    v-if="frontmatter.footer !== false"
    ref="footerRef"
    class="VPFooter site-footer site-footer--fixed"
  >
    <div class="container">
      <p v-if="theme.footer?.message" class="message">
        {{ theme.footer.message }}
      </p>
      <p v-if="theme.footer?.copyright" class="copyright">
        {{ theme.footer.copyright }}
      </p>
      <p class="site-footer-meta">
        <template v-if="isZh">
          站点最后更新：<time :datetime="siteMeta.lastUpdated">{{ formattedSiteUpdated }}</time>
          <span class="sep" aria-hidden="true">·</span>
          构建
          <a
            v-if="siteMeta.commitSha"
            class="site-footer-link"
            :href="buildLink"
            target="_blank"
            rel="noreferrer"
            >{{ siteMeta.shortSha }}</a
          >
          <span v-else>{{ siteMeta.shortSha }}</span>
          <span class="sep" aria-hidden="true">·</span>
          <a
            class="site-footer-link"
            href="https://github.com/MvvmAIO/Prism.SourceGenerators.Docs"
            target="_blank"
            rel="noreferrer"
            >文档仓库</a
          >
        </template>
        <template v-else-if="isJa">
          サイト最終更新：
          <time :datetime="siteMeta.lastUpdated">{{ formattedSiteUpdated }}</time>
          <span class="sep" aria-hidden="true">·</span>
          ビルド
          <a
            v-if="siteMeta.commitSha"
            class="site-footer-link"
            :href="buildLink"
            target="_blank"
            rel="noreferrer"
            >{{ siteMeta.shortSha }}</a
          >
          <span v-else>{{ siteMeta.shortSha }}</span>
          <span class="sep" aria-hidden="true">·</span>
          <a
            class="site-footer-link"
            href="https://github.com/MvvmAIO/Prism.SourceGenerators.Docs"
            target="_blank"
            rel="noreferrer"
            >ドキュメントリポジトリ</a
          >
        </template>
        <template v-else>
          Site last updated:
          <time :datetime="siteMeta.lastUpdated">{{ formattedSiteUpdated }}</time>
          <span class="sep" aria-hidden="true">·</span>
          Build
          <a
            v-if="siteMeta.commitSha"
            class="site-footer-link"
            :href="buildLink"
            target="_blank"
            rel="noreferrer"
            >{{ siteMeta.shortSha }}</a
          >
          <span v-else>{{ siteMeta.shortSha }}</span>
          <span class="sep" aria-hidden="true">·</span>
          <a
            class="site-footer-link"
            href="https://github.com/MvvmAIO/Prism.SourceGenerators.Docs"
            target="_blank"
            rel="noreferrer"
            >Docs repo</a
          >
        </template>
      </p>
    </div>
  </footer>
</template>
