<script lang="ts">
import { defineComponent } from 'vue'
import ContractForm from '@/components/ContractForm.vue'
import axios from 'axios'
import { API_URL } from '@/constants/constants'
import type { ContractRequest } from '@/models/requests/contractRequest'

export default defineComponent({
  name: 'ContractCreateView',
  components: { ContractForm },
  methods: {
    async createContract(contractRequest: ContractRequest) {
      await axios.post(`${API_URL}/contracts`, contractRequest)
      this.$router.push(`/contracts`)
    }
  }
})
</script>

<template>
  <div class="p-10 bg-gray-50">
    <h1 class="text-3xl text-green-600 mb-6">Create New Contract</h1>
    <contract-form @on-submit="createContract" />
  </div>
</template>

<style scoped></style>
