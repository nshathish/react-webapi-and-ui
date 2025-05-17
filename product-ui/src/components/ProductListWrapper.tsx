import { lazy, Suspense } from 'react';

import ErrorBoundary from './ErrorBoundary.tsx';

const ProductList = lazy(() => import('./ProductList.tsx'));

/*const ProductList = lazy(
  () =>
    new Promise<{ default: ComponentType }>((resolve) => {
      setTimeout(() => {
        import('./ProductList').then((module) =>
          resolve({ default: module.default }),
        );
      }, 2000);
    }),
);*/

function BigSpinner() {
  return <h2>🌀 Loading...</h2>;
}

function ErrorFallback() {
  return (
    <div style={{ color: 'red' }}>
      <h2>Something went wrong.</h2>
      <p>Please try again later.</p>
    </div>
  );
}

export default function ProductListWrapper() {
  return (
    <ErrorBoundary fallback={<ErrorFallback />}>
      <Suspense fallback={<BigSpinner />}>
        <ProductList />
      </Suspense>
    </ErrorBoundary>
  );
}
