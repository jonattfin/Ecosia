// import * as nextImage from "next/image";
import React from "react";

import { ImageOptimisationProvider } from "../src/providers/image-provider";

export const parameters = {
  actions: { argTypesRegex: "^on[A-Z].*" },
  controls: {
    matchers: {
      color: /(background|color)$/i,
      date: /Date$/,
    },
  },
};

export const decorators = [
  (Story) => (
    <ImageOptimisationProvider unoptimized={true}>
      <Story />
    </ImageOptimisationProvider>
  ),
];
