<script lang="ts">
import { defineComponent } from 'vue'
import { RouterLink } from 'vue-router'

export default defineComponent({
  name: 'ContractNavigation',
  components: { RouterLink }
})
</script>

<template>
  <nav class="text-center md:text-left space-x-4 p-10 bg-gray-50">
    <RouterLink to="/">Home</RouterLink>
    <RouterLink to="/contracts">Contracts</RouterLink>
  </nav>
</template>

<style scoped></style>
