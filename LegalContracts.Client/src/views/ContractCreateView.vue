<script lang="ts">
import { defineComponent } from 'vue'
import ContractForm from '@/components/ContractForm.vue'
import { Contract } from '@/models/contract'
import axios from 'axios'

//todo extract
const API_URL = 'https://localhost:5001/api'

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
  <contract-form @on-submit="createContract" />
</template>

<style scoped></style>
