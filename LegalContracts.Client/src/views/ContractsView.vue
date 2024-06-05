<script lang="ts">
const API_URL = 'https://localhost:5001'

export default {
  components: {},
  data() {
    return {
      contracts: []
    }
  },
  created() {
    this.getContracts()
  },
  methods: {
    async getContracts() {
      const url = `${API_URL}/contracts`
      this.contracts = await (await fetch(url)).json()
    }
  }
}
</script>

<template>
  <div>
    <h1>Contracts</h1>
    <router-link to="/contracts/new">Create New Contract</router-link>
    <ul>
      <li v-for="contract in contracts" v-bind:key="contract.id">
        {{ contract.id }}
        {{ contract.authorName }}
        {{ contract.legalEntityName }}
        {{ contract.legalEntityDescription }}
        {{ contract.createdAt }}
        {{ contract.updatedAt }}
      </li>
    </ul>
  </div>
</template>

<style scoped></style>
