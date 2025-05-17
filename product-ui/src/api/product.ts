import axios from 'axios';

import type { Product } from '../types/product.ts';

const API_BASE = import.meta.env.DEV ? 'api' : import.meta.env.VIT_API_URL;

export const fetchProducts = () => axios.get<Product[]>(`${API_BASE}/products`);

export const createProduct = (p: Product) =>
  axios.post(`${API_BASE}/products`, p);

export const updateProduct = (id: number, p: Product) =>
  axios.put(`${API_BASE}/products/${id}`, p);

export const deleteProduct = (id: number) =>
  axios.delete(`${API_BASE}/products/${id}`);
