<script lang="ts">
import { defineComponent } from 'vue'
import type { Contract } from '@/models/Contract'
import axios from 'axios'
import { API_URL } from '@/constants/constants'

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
      const response = await axios.get(`${API_URL}/contracts`)
      this.contracts = response.data
    },
    async deleteContract(id: number) {
      await axios.delete(`${API_URL}/contracts/${id}`)
      this.getContracts()
    }
  }
})
</script>

<template>
  <div>
    <h1>Contracts</h1>
    <router-link to="/contracts/new">Create New Contract</router-link>
    <div>
      <div v-for="contract in contracts" :key="contract.id">
        {{ contract.id }}
        {{ contract.authorName }}
        {{ contract.legalEntityName }}
        {{ contract.legalEntityDescription }}
        {{ contract.createdAt }}
        {{ contract.updatedAt }}
        <input type="button" @click="deleteContract(contract.id)" value="Delete" />
      </div>
    </div>
  </div>
</template>

<style scoped></style>
