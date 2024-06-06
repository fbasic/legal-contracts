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
  <contract-form @on-submit="createContract" />
</template>

<style scoped></style>
