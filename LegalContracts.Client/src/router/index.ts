import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ContractsView from '../views/ContractsView.vue'
import ContractCreateView from '@/views/ContractCreateView.vue'

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
    }
  ]
})

export default router
