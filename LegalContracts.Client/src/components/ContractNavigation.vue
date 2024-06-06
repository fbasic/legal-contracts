<script lang="ts">
import { defineComponent } from 'vue'
import { RouterLink } from 'vue-router'

export default defineComponent({
  name: 'ContractNavigation',
  components: { RouterLink }
})
</script>

<template>
  <nav class="text-center md:text-left space-x-4 p-10 bg-gray-200">
    <RouterLink class="hover:underline" to="/">Home</RouterLink>
    <RouterLink class="hover:underline" to="/contracts">Contracts</RouterLink>
  </nav>
</template>

<style scoped></style>
