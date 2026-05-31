<script setup lang="ts">
import { computed } from 'vue'
import { useData, useRoute } from 'vitepress'
import { commitUrl, siteMeta } from '../site-meta.shared'
import { formatLocalDateTime } from './format-local-datetime'

const { lang, theme } = useData()
const route = useRoute()

const isHome = computed(() => route.path === '/' || route.path.endsWith('/index.html'))

const copy = computed(() => {
  if (lang.value === 'zh-Hans' || lang.value === 'zh-cn') {
    return {
      updated: '文档更新',
      commit: '提交',
      repo: '文档仓库',
      builtWith: '本站由 VitePress 构建。',
    }
  }
  if (lang.value === 'ja') {
    return {
      updated: 'ドキュメント更新',
      commit: 'コミット',
      repo: 'ドキュメントリポジトリ',
      builtWith: 'このサイトは VitePress で構築されています。',
    }
  }
  return {
    updated: 'Documentation updated',
    commit: 'Commit',
    repo: 'Docs repository',
    builtWith: 'This site is built with VitePress.',
  }
})

const formattedUpdated = computed(() =>
  formatLocalDateTime(siteMeta.lastUpdated, lang.value),
)
</script>

<template>
  <footer v-if="isHome" class="site-footer">
    <p class="site-footer__line">
      <strong>{{ copy.updated }}:</strong>
      {{ formattedUpdated }}
    </p>
    <p class="site-footer__line">
      <strong>{{ copy.commit }}:</strong>
      <a
        v-if="siteMeta.commitSha"
        :href="commitUrl(siteMeta.commitSha)"
        target="_blank"
        rel="noopener noreferrer"
      >
        {{ siteMeta.shortSha }}
      </a>
      <span v-else>{{ siteMeta.shortSha }}</span>
    </p>
    <p class="site-footer__line">
      <a
        href="https://github.com/MvvmAIO/Prism.SourceGenerators.Docs"
        target="_blank"
        rel="noopener noreferrer"
      >
        {{ copy.repo }}
      </a>
      ·
      <span>{{ copy.builtWith }}</span>
    </p>
    <p v-if="theme.footer?.message" class="site-footer__license">
      {{ theme.footer.message }}
    </p>
  </footer>
</template>

<style scoped>
.site-footer {
  max-width: var(--vp-layout-max-width);
  margin: 2rem auto 0;
  padding: 1.5rem var(--vp-layout-home-padding) 2.5rem;
  border-top: 1px solid var(--vp-c-divider);
  font-size: 0.875rem;
  color: var(--vp-c-text-2);
  line-height: 1.6;
}

.site-footer__line {
  margin: 0.35rem 0;
}

.site-footer__line a {
  color: var(--vp-c-brand-1);
}

.site-footer__license {
  margin: 1rem 0 0;
  font-size: 0.8125rem;
}
</style>
