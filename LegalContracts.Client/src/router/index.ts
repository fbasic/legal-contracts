import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ContractsView from '../views/ContractsView.vue'
import ContractCreateView from '@/views/ContractCreateView.vue'
import ContractDetailsView from '@/views/ContractDetailsView.vue'
import ContractEditView from '@/views/ContractEditView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/contracts',
      name: 'contracts',
      component: ContractsView
    },
    {
      path: '/contracts/new',
      name: 'contracts-new',
      component: ContractCreateView
    },
    {
      path: '/contracts/:id',
      name: 'contract-details',
      component: ContractDetailsView,
      props: true
    },
    {
      path: '/contracts/:id/edit',
      name: 'contract-edit',
      component: ContractEditView,
      props: true
    }
  ]
})

export default router
