import type { Product } from '../types/product.ts';

const API_BASE = '/api';

let getProductsPromise: Promise<Product[]> | null = null;

export function getProducts(): Promise<Product[]> {
  if (!getProductsPromise) {
    getProductsPromise = fetch(`${API_BASE}/products`)
      .then((res) => {
        if (!res.ok) {
          throw new Error(`Failed to fetch products: ${res.statusText}`);
        }
        return res.json();
      })
      .catch((error) => {
        console.error('Error fetching products:', error);
        throw error;
      });
  }

  return getProductsPromise;
}
