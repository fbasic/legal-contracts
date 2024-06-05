<script lang="ts">
import { defineComponent } from 'vue'
import axios from 'axios'
import type { CreateContractRequest } from '@/models/requests/createContractRequest'

//todo extract
const API_URL = 'https://localhost:5001'

export default defineComponent({
  name: 'ContractCreateView',
  methods: {
    async createContract() {
      const contractRequest: CreateContractRequest = {
        authorName: 'John Smith',
        legalEntityName: 'MegaCorp',
        legalEntityDescription: 'Big Company'
      }
      await axios.post(`${API_URL}/contracts`, contractRequest)
    }
  }
})
</script>

<template>
  <button @click="createContract">Add</button>
</template>

<style scoped></style>
