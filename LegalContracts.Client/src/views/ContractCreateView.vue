<script lang="ts">
import { defineComponent } from 'vue'
import ContractForm from '@/components/ContractForm.vue'
import { Contract } from '@/models/contract'
import axios from 'axios'
import { API_URL } from '@/constants/constants'

export default defineComponent({
  name: 'ContractCreateView',
  components: { ContractForm },
  methods: {
    async createContract(contract: Contract) {
      await axios.post(`${API_URL}/contracts`, contract)
    }
  }
})
</script>

<template>
  <div class="p-10">
    <h1 class="text-3xl text-green-600 mb-6">Create New Contract</h1>
    <contract-form @on-submit="createContract" />
  </div>
</template>

<style scoped></style>
