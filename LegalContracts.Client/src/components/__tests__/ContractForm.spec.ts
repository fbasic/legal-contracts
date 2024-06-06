import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import ContractForm from '../../components/ContractForm.vue'
import { nextTick } from 'vue'

describe('ContractForm', () => {
  it('shows validation error when fields are empty on submit', async () => {
    const wrapper = mount(ContractForm, {
      props: {
        contract: null
      }
    })

    // Simulate form submission
    await wrapper.find('form').trigger('submit.prevent')
    await nextTick()

    // Check for validation messages
    expect(wrapper.find('#authorName + div.text-red-600').exists()).toBe(true)
    expect(wrapper.find('#legalEntityName + div.text-red-600').exists()).toBe(true)
  })
})
