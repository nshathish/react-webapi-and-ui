import type { Product } from '../types/product.ts';

const API_BASE = import.meta.env.DEV ? 'api' : import.meta.env.VITE_API_URL;

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
