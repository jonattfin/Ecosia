import styled from "@emotion/styled";
import { Grid } from "@mui/material";
import Image from "next/image";
import { ITranslationFunc, withTranslations } from "../../../helpers";
import { Language } from "../../../providers/context";

import {
  AppColor,
  MainSubtitleDiv,
  MainTitleDiv,
} from "../../../shared-components";

import * as Images from "./images";

const Component = ({ t }: { t: ITranslationFunc }) => {
  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <ContainerDiv>
            <MainTitleDiv>{t("forMobile")}</MainTitleDiv>
            <MainSubtitleDiv>
              {t("plantTreesWhileSearching")} <br /> {t("withMobile")}
            </MainSubtitleDiv>
            <div>
              <Image src={Images.AppStoreImage} alt={"app store"} />
              <Image src={Images.PlayStoreImage} alt={"play store"} />
            </div>
          </ContainerDiv>
        </Grid>
      </Grid>
    </section>
  );
}

// Styled Components

const ContainerDiv = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;
  height: 50vh;

  background-color: ${AppColor.AliceBlue};
`;

// translations

const translations = {
  [Language.English]: {
    forMobile: "Ecosia for Mobile",
    plantTreesWhileSearching: "Plant trees while searching the web",
    withMobile: "with your mobile phone or tablet.",
  },
  [Language.French]: {
    forMobile: "Ecosia pour Mobile",
    plantTreesWhileSearching: "Plantez des arbres en effectuant une recherche sur le Web",
    withMobile: "avec votre téléphone portable ou votre tablette.",
  },
};

export default withTranslations(translations)(Component);