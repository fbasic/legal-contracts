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
    },
    navigateTo(route: string) {
      this.$router.push(route)
    }
  }
})
</script>

<template>
  <div class="p-10 bg-gray-50">
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
        class="bg-white p-6 rounded-lg shadow-md relative"
      >
        <i
          @click="navigateTo(`/contracts/${contract.id}/edit`)"
          class="fas fa-pencil-alt text-gray-600 absolute top-5 right-12 cursor-pointer"
        ></i>
        <i
          @click="deleteContract(contract.id)"
          class="fas fa-trash-alt text-red-600 cursor-pointer absolute top-5 right-4"
        ></i>
        <h2 class="text-2xl font-semibold text-gray-800 mb-2">
          {{ contract.authorName }}
        </h2>
        <p class="text-gray-600 mb-2">
          {{ contract.legalEntityName }}
        </p>
        <p class="text-gray-600 mb-2">
          {{ contract.legalEntityDescription }}
        </p>
        <RouterLink
          :to="`contracts/${contract.id}`"
          class="text-green-500 text-sm underline cursor-pointer"
        >
          See Details
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
