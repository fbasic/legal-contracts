<script lang="ts">
import { defineComponent } from 'vue'
import type { Contract } from '@/models/Contract'
import axios from 'axios'

//todo extract
const API_URL = 'https://localhost:5001/api'

export default defineComponent({
  name: 'ContractsView',
  components: {},
  data() {
    return {
      contracts: [] as Contract[]
    }
  },
  created() {
    this.getContracts()
  },
  methods: {
    async getContracts(): Contract[] {
      const url = `${API_URL}/contracts`
      const response = await axios.get(url)
      this.contracts = response.data
    }
  }
})
</script>

<template>
  <div>
    <h1>Contracts</h1>
    <router-link to="/contracts/new">Create New Contract</router-link>
    <ul>
      <li v-for="contract in contracts" :key="contract.id">
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
