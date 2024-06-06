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
  <div class="p-10">
    <h1 class="text-3xl text-green-600 mb-6">Contracts</h1>
    <RouterLink
      to="/contracts/new"
      class="inline-block bg-green-600 text-white py-2 px-4 rounded hover:bg-green-800 mb-6"
    >
      New Contract
    </RouterLink>
    <div class="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-3">
      <div
        v-for="contract in contracts"
        :key="contract.id"
        class="bg-gray-100 p-6 rounded-lg shadow-md relative"
      >
        <i
          @click="deleteContract(contract.id)"
          class="fas fa-trash-alt text-red-600 cursor-pointer absolute top-5 right-4"
        ></i>
        <h2 class="text-2xl font-semibold text-gray-800 mb-2">
          {{ contract.authorName }}
        </h2>
        <p class="text-gray-600 mb-2">
          {{ contract.legalEntityName }} - {{ contract.legalEntityDescription }}
        </p>
        <p class="text-gray-500 text-sm mb-2">
          <strong>Created At:</strong>
          {{ new Date(contract.createdAt).toLocaleString() }}
        </p>
        <p class="text-gray-500 text-sm mb-4">
          <span v-if="contract.updatedAt">
            <strong>Updated At:</strong> {{ new Date(contract.updatedAt).toLocaleString() }}
          </span>
        </p>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
