import React from "react";

interface ImageOptions {
  unoptimized: boolean;
}

interface ProviderProps extends ImageOptions {
  children: React.ReactNode;
}

export const ImageOptimisationContext = React.createContext<ImageOptions>({
  unoptimized: false,
});

// This provider is useful for allowing storybook to use a unoptimized: true
export const ImageOptimisationProvider = ({
  children,
  unoptimized,
}: ProviderProps) => {
  return (
    <ImageOptimisationContext.Provider value={{ unoptimized }}>
      {children}
    </ImageOptimisationContext.Provider>
  );
};
