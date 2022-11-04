import React from "react";
import NextImage, { ImageProps } from "next/image";

import { ImageOptimisationContext } from "../../providers/image-provider";

const Image = (props: ImageProps) => {
  const { unoptimized } = React.useContext(ImageOptimisationContext);
  return <NextImage {...props} unoptimized={unoptimized} />;
};

export default Image;
