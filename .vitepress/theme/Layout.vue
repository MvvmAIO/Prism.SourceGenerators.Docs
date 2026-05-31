<script setup lang="ts">
import DefaultTheme from 'vitepress/theme'
import SiteFooter from './SiteFooter.vue'

const Layout = DefaultTheme.Layout
</script>

<template>
  <Layout>
    <template #layout-bottom>
      <SiteFooter />
    </template>
  </Layout>
</template>
