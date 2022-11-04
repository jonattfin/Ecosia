import { Grid } from "@mui/material";
import styled from "@emotion/styled";

import { Language } from "../../../providers/context";

import {
  Image,
  MainTitleDiv,
  MainSubtitleDiv,
  AppColor,
} from "../../../shared-components";
import * as Images from "./images";
import { ITranslationFunc, withTranslations } from "../../../helpers";

const Component = ({ t }: { t: ITranslationFunc }) => {
  const imageProps = { width: 300, height: 0 };
  imageProps.height = imageProps.width * 0.7;

  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <MainTitleDiv data-test="countries-title">
            {t("whereAreTreesPlanted")}
          </MainTitleDiv>
          <MainSubtitleDiv data-test="countries-subtitle">
            {t("wePlantIn30Countries")}
          </MainSubtitleDiv>
        </Grid>
        <Grid item xs={12} xl={4}>
          <Image src={Images.BrazilImage} alt="brazil" {...imageProps} />
          <NameDiv>Brazil</NameDiv>
          <TextDiv>{t("treesInBrasil")}</TextDiv>
        </Grid>
        <Grid item xs={12} xl={4}>
          <Image
            src={Images.BurkinaFasoImage}
            alt="burkina faso"
            {...imageProps}
          />
          <NameDiv>Burkina Faso</NameDiv>
          <TextDiv>{t("treesInBurkinaFaso")}</TextDiv>
        </Grid>
        <Grid item xs={12} xl={4}>
          <Image src={Images.IndonesiaImage} alt="indonesia" {...imageProps} />
          <NameDiv>Indonesia</NameDiv>
          <TextDiv>{t("treesInIndonesia")}</TextDiv>
        </Grid>
        <Grid item>&nbsp;</Grid>
      </Grid>
    </section>
  );
};

// Styled Components

const NameDiv = styled.div`
  padding: 1%;
  border-left: 5px solid ${AppColor.Teal};
  text-transform: uppercase;
`;

const TextDiv = styled.div`
  padding-top: 2%;
`;

// translations

const translations = {
  [Language.English]: {
    whereAreTreesPlanted: "Where are your trees being planted?",
    wePlantIn30Countries: "We plant in 30+ countries with local organizations",
    treesInBrasil:
      "Your trees in Brazil protect thousands of endangered plants and animals.",
    treesInBurkinaFaso:
      "By planting trees in Burkina Faso, you restore desertified land to its former fertility.",
    treesInIndonesia:
      "In Indonesia, your searches bring back forests on former palm oil plantations while creating alternative sources of income.",
  },
  [Language.French]: {
    whereAreTreesPlanted: "Où vos arbres sont-ils plantés?",
    wePlantIn30Countries:
      "Nous plantons dans plus de 30 pays avec des organisations locales",
    treesInBrasil:
      "Vos arbres au Brésil protègent des milliers de plantes et d'animaux en voie de disparition.",
    treesInBurkinaFaso:
      "En plantant des arbres au Burkina Faso, vous redonnez aux terres désertifiées leur fertilité d'antan.",
    treesInIndonesia:
      "En Indonésie, vos recherches ramènent des forêts sur d'anciennes plantations de palmiers à huile tout en créant des sources alternatives de revenus.",
  },
};

export default withTranslations(translations)(Component);
