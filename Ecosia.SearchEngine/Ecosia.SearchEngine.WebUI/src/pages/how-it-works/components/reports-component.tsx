import styled from "@emotion/styled";
import { Button, Grid } from "@mui/material";
import { ITranslationFunc, withTranslations } from "../../../helpers";
import { Language } from "../../../providers/context";

import { Image, MainTitleDiv } from "../../../shared-components";
import * as Images from "./images";

const Component = ({ t }: { t: ITranslationFunc }) => {
  const imageProps = { width: 100, height: 0 };
  imageProps.height = imageProps.width * 1;

  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <ContainerDiv>
            <div>
              <Image
                src={Images.ReportsImage}
                alt="transparency"
                {...imageProps}
              />
            </div>
            <MainTitleDiv>{t("weKnowTrust")}</MainTitleDiv>
            <ContentDiv>
              {t("wePublishMonthlyTitle")} <br />{" "}
              {t("wePublishMonthlySubtitle")}
            </ContentDiv>
            <div>
              <Button variant="contained">{t("viewReports")}</Button>
            </div>
          </ContainerDiv>
        </Grid>
      </Grid>
    </section>
  );
};

// Styled Components

const ContainerDiv = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;
  height: 50vh;
`;

const ContentDiv = styled.div`
  font-size: x-large;
`;

// translations

const translations = {
  [Language.English]: {
    weKnowTrust: "We know trust has to be earned",
    wePublishMonthlyTitle: `That is why we publish our monthly financial reports and tree
    planting receipts.`,
    wePublishMonthlySubtitle:
      "This way you can hold us accountable as we follow our journey to a reforested world.",
    viewReports: "View Reports",
  },
  [Language.French]: {
    weKnowTrust: "Nous savons que la confiance doit être gagnée",
    wePublishMonthlyTitle: `C'est pourquoi nous publions nos rapports financiers mensuels et notre arbre reçus de plantation.`,
    wePublishMonthlySubtitle:
      "De cette façon, vous pouvez nous tenir responsables en tant que nous suivons notre voyage vers un monde reboisé.",
    viewReports: "Afficher les rapports",
  },
};

export default withTranslations(translations)(Component);
