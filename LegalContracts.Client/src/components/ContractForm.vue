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
      legalEntityDescription: this.contract?.legalEntityDescription || '',
      triedSubmit: false
    }
  },
  computed: {
    isValidAuthorName() {
      return this.authorName && this.authorName.length > 0
    },
    isValidLegalName() {
      return this.legalEntityName && this.legalEntityName.length > 0
    },
    isFormValid() {
      return !this.triedSubmit || (this.isValidAuthorName && this.isValidLegalName)
    }
  },
  methods: {
    async handleSubmit() {
      this.triedSubmit = true

      if (this.isFormValid) {
        this.$emit('on-submit', {
          authorName: this.authorName,
          legalEntityName: this.legalEntityName,
          legalEntityDescription: this.legalEntityDescription
        })

        this.$router.push(`/contracts`)
      }
    }
  }
})
</script>

<template>
  <form @submit.prevent="handleSubmit" class="w-full md:w-64">
    <div class="mb-4">
      <label for="authorName" class="block text-sm font-medium text-gray-700">Author Name</label>
      <input
        type="text"
        id="authorName"
        v-model="authorName"
        class="w-full mt-1 p-2 border-gray-500 rounded-md focus:outline-none focus:ring focus:ring-green-300"
      />
      <div v-if="triedSubmit && !isValidAuthorName" class="text-red-600 text-sm mt-1">
        Please enter a valid author name
      </div>
    </div>
    <div class="mb-4">
      <label for="legalEntityName" class="block text-sm font-medium text-gray-700"
        >Legal Entity Name</label
      >
      <input
        type="text"
        id="legalEntityName"
        v-model="legalEntityName"
        class="w-full mt-1 p-2 border-gray-500 rounded-md focus:outline-none focus:ring focus:ring-green-300"
      />
      <div v-if="triedSubmit && !isValidLegalName" class="text-red-600 text-sm mt-1">
        Please enter a valid legal entity name
      </div>
    </div>
    <div class="mb-4">
      <label for="legalEntityDescription" class="block text-sm font-medium text-gray-700"
        >Legal Entity Description</label
      >
      <textarea
        type="text"
        id="legalEntityDescription"
        v-model="legalEntityDescription"
        class="w-full mt-1 p-2 border-gray-500 rounded-md focus:outline-none focus:ring focus:ring-green-300"
      />
    </div>
    <button
      type="submit"
      class="bg-indigo-600 text-white py-2 px-4 rounded hover:bg-indigo-700 transition-colors duration-300"
    >
      Submit
    </button>
  </form>
</template>

<style scoped></style>
