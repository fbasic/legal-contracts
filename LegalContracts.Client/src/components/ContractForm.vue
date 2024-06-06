<script lang="ts">
import { defineComponent, PropType } from 'vue'
import type { Contract } from '@/models/contract'

export default defineComponent({
  name: 'ContractForm',
  props: {
    contract: { type: Object as PropType<Contract | null> }
  },
  data() {
    return {
      authorName: this.contract?.authorName || '',
      legalEntityName: this.contract?.legalEntityName || '',
      legalEntityDescription: this.contract?.legalEntityDescription || ''
    }
  },
  computed: {
    isValidAuthorName() {
      return false
    }
  },
  methods: {
    async handleSubmit() {
      this.$emit('on-submit', {
        authorName: this.authorName,
        legalEntityName: this.legalEntityName,
        legalEntityDescription: this.legalEntityDescription
      })
    }
  }
})
</script>

<template>
  <form @submit.prevent="handleSubmit">
    <label>Author Name</label>
    <input type="text" required v-model="authorName" />
    <div v-if="!isValidAuthorName" class="error">Please enter a valid author name</div>
    <label>Legal Entity Name</label>
    <input type="text" required v-model="legalEntityName" />
    <div v-if="!isValidAuthorName" class="error">Please enter a valid author name</div>
    <label>Legal Entity Description</label>
    <input type="text" required v-model="legalEntityDescription" />

    <input type="submit" />
  </form>
</template>

<style scoped></style>
