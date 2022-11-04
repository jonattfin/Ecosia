import { Grid } from "@mui/material";
import styled from "@emotion/styled";

import { Image, MainTitleDiv } from "../../../shared-components";
import * as Images from "./images";
import { Language } from "../../../providers/context";
import { ITranslationFunc, withTranslations } from "../../../helpers";

const Component = ({ t }: { t: ITranslationFunc }) => {
  const imageProps = { width: 200, height: 0 };
  imageProps.height = imageProps.width * 0.5;

  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <ParentContainerDiv>
            <MainTitleDiv>{t("howItWorks")}</MainTitleDiv>
            <ChildContainerDiv>
              <ImageContainerDiv>
                <LogoImage
                  src={Images.AdsImage}
                  alt="tdlr"
                  {...imageProps}
                ></LogoImage>
                <ContentDiv>{t("searchAdds")}</ContentDiv>
              </ImageContainerDiv>
              <ImageContainerDiv>
                <LogoImage
                  src={Images.ForrestLogo}
                  alt="tdlr"
                  {...imageProps}
                ></LogoImage>
                <ContentDiv>{t("webSearch")}</ContentDiv>
              </ImageContainerDiv>
              <ImageContainerDiv>
                <LogoImage
                  src={Images.IncomeImage}
                  alt="tdlr"
                  {...imageProps}
                ></LogoImage>
                <ContentDiv>{t("incomeUse")}</ContentDiv>
              </ImageContainerDiv>
            </ChildContainerDiv>
          </ParentContainerDiv>
        </Grid>
      </Grid>
    </section>
  );
};

// Styled Components

const ParentContainerDiv = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
  height: 40vh;
`;

const ChildContainerDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
`;

const ImageContainerDiv = styled.div`
  text-align: center;
`;

const LogoImage = styled(Image)`
  max-width: 150px;
  padding: 20px;
`;

const ContentDiv = styled.div`
  padding: 40px;
`;

// translations

const translations = {
  [Language.English]: {
    searchAdds: "Search ads generate income for Ecosia.",
    incomeUse: "Ecosia uses this income to plant trees",
    webSearch: "You search the web with Ecosia.",
    howItWorks: "How it works",
  },
  [Language.French]: {
    searchAdds: "Les annonces de recherche génèrent des revenus pour Ecosia.",
    incomeUse: "Ecosia utilise ce revenu pour planter des arbres",
    webSearch: "Vous effectuez des recherches sur le Web avec Ecosia.",
    howItWorks: "Comment ça marche",
  },
};

export default withTranslations(translations)(Component);
