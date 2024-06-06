<script setup lang="ts">
import { RouterView } from 'vue-router'
import ContractHeader from '@/components/ContractHeader.vue'
import ContractNavigation from '@/components/ContractNavigation.vue'
</script>

<template>
  <ContractHeader />
  <ContractNavigation />
  <main>
    <RouterView />
  </main>
</template>

<style scoped></style>
