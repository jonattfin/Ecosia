import { Grid } from "@mui/material";
import styled from "@emotion/styled";

import { Image } from "../../../shared-components";
import * as Images from "./images";

export default function Component() {
  const imageProps = { width: 100, height: 0 };
  imageProps.height = imageProps.width * 0.5;

  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <BrandsContainerDiv>
            {getBrands().map((brand, index) => (
              <Image
                src={brand}
                key={`brand_image_${index}`}
                alt="tdlr"
                {...imageProps}
              ></Image>
            ))}
          </BrandsContainerDiv>
        </Grid>
      </Grid>
    </section>
  );
}

function getBrands() {
  const {
    UpWorthyImage,
    ScientificImage,
    GuardianImage,
    SalonImage,
    ForbesImage,
  } = Images;

  return [
    UpWorthyImage,
    ScientificImage,
    GuardianImage,
    SalonImage,
    ForbesImage,
  ];
}

// Styled Components

const BrandsContainerDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  align-items: center;
  height: 5vh;
  background-color: #ededed;
`;
