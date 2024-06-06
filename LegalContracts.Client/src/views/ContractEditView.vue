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
    }
  }
})
</script>

<template>
  <div v-if="contract">
    <contract-form :contract="contract" @on-submit="updateContract" />
  </div>
  <div v-else>
    <p>Loading...</p>
  </div>
</template>

<style scoped></style>
