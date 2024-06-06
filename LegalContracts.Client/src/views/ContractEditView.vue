<script lang="ts">
import { defineComponent } from 'vue'
import ContractForm from '@/components/ContractForm.vue'
import axios from 'axios'
import { Contract } from '@/models/contract'
import type { ContractRequest } from '@/models/requests/contractRequest'
import { API_URL } from '@/constants/constants'

export default defineComponent({
  name: 'ContractEditView',
  data() {
    return {
      contract: null as Contract | null
    }
  },
  components: { ContractForm },
  created() {
    const id = this.$route.params.id as string
    this.getContract(id).then((contract) => {
      this.contract = contract
    })
  },
  methods: {
    async getContract(id: string) {
      const response = await axios.get(`${API_URL}/contracts/${id}`)
      return response.data
    },
    async updateContract(contractRequest: ContractRequest) {
      await axios.put(`${API_URL}/contracts/${this.contract?.id}`, contractRequest)
      this.$router.push(`/contracts`)
    }
  }
})
</script>

<template>
  <div v-if="contract" class="p-10 bg-gray-50">
    <h1 class="text-3xl text-green-600 mb-6">Edit Contract</h1>
    <contract-form :contract="contract" @on-submit="updateContract" />
  </div>
</template>

<style scoped></style>
