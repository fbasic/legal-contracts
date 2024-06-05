<script setup lang="ts">
import HelloWorld from '@/components/HelloWorld.vue'
import { RouterLink } from 'vue-router'
</script>

<template>
  <main>
    <div class="wrapper">
      <HelloWorld msg="Legal Contracts" />
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/contracts">Contracts</RouterLink>
      </nav>
    </div>
  </main>
</template>
