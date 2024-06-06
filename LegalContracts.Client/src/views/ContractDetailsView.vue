<script lang="ts">
import { defineComponent } from 'vue'
import axios from 'axios'
import type { Contract } from '@/models/contract'
import { API_URL } from '@/constants/constants'

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
  <div class="p-10 bg-gray-50">
    <div v-if="contract">
      <h1 class="text-3xl text-green-600 mb-6">Contract Details</h1>
      <p class="block text-sm font-medium text-gray-700">ID</p>
      <p class="text-gray-600 mb-2">{{ contract.id }}</p>
      <p class="block text-sm font-medium text-gray-700">Author Name</p>
      <p class="text-gray-600 mb-2">{{ contract.authorName }}</p>
      <p class="block text-sm font-medium text-gray-700">Legal Entity Name</p>
      <p class="text-gray-600 mb-2">{{ contract.legalEntityName }}</p>
      <p class="block text-sm font-medium text-gray-700">Legal Entity Description</p>
      <p class="text-gray-600 mb-2">{{ contract.legalEntityDescription }}</p>
      <p class="block text-sm font-medium text-gray-700">Created At</p>
      <p class="text-gray-600 mb-2">{{ contract.createdAt }}</p>
      <p class="block text-sm font-medium text-gray-700">Updated At</p>
      <p class="text-gray-600 mb-2">{{ contract.updatedAt }}</p>
    </div>
  </div>
</template>

<style scoped></style>
