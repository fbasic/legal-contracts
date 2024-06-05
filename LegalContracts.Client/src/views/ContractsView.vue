<script lang="ts">
export default {
  components: {},
  data() {
    return {
      contracts: []
    }
  },
  methods: {},
  mounted() {
    console.log('contracts view mounted!')
  }
}
</script>

<template>
  <div>
    <h1>Contracts</h1>
    <router-link to="/contracts/new">Create New Contract</router-link>
  </div>
</template>

<style scoped></style>
