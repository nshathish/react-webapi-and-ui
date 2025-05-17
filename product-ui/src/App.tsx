import { useEffect } from 'react';

import ProductListWrapper from './components/ProductListWrapper.tsx';

export default function App() {
  console.log('Inlined:', import.meta.env);

  useEffect(() => {
    console.log('API Base:', import.meta.env.VITE_API_URL);
  }, []);

  return (
    <div className="max-w-3xl mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Product Manager</h1>
      <ProductListWrapper />
    </div>
  );
}
