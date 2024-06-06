<script lang="ts">
import { defineComponent } from 'vue'
import axios from 'axios'
import type { Contract } from '@/models/contract'

//todo extract
const API_URL = 'https://localhost:5001/api'

export default defineComponent({
  name: 'ContractDetailsView',
  data() {
    return {
      contract: null as Contract | null
    }
  },
  created() {
    const id = this.$route.params.id as string
    this.getContract(id)
  },
  methods: {
    async getContract(id: string) {
      const response = await axios.get(`${API_URL}/contracts/${id}`)
      this.contract = response.data
    }
  }
})
</script>

<template>
  <h2>Contract Details</h2>
  <ul>
    <li>ID: {{ contract.id }}</li>
    <li>Author Name: {{ contract.authorName }}</li>
    <li>Legal Entity Name: {{ contract.legalEntityName }}</li>
    <li>Legal Entity Description: {{ contract.legalEntityDescription }}</li>
    <li>Created At: {{ contract.createdAt }}</li>
    <li>Updated At: {{ contract.updatedAt }}</li>
  </ul>
</template>

<style scoped></style>
