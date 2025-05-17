import { use } from 'react';

import ProductList from './ProductList.tsx';

import { getProducts } from '../services/productService.ts';

export default function ProductListWrapper() {
  const products = use(getProducts());
  return <ProductList products={products} />;
}
