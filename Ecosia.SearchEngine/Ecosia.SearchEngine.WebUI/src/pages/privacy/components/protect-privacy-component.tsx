import { Grid } from "@mui/material";
import styled from "@emotion/styled";
import ArrowDropDownCircleIcon from "@mui/icons-material/ArrowDropDownCircle";
import Image from "next/image";

import * as Images from "./images";
import { AppColor } from "../../../shared-components";
import { Language } from "../../../providers/context";
import { ITranslationFunc, withTranslations } from "../../../helpers";

const Component = ({ t }: { t: ITranslationFunc }) => {
  return (
    <Grid container spacing={2}>
      <Grid item xs={12} xl={12}>
        <DivContainer>
          <AboveTitle>{t("weProtectYourPrivacy")}</AboveTitle>
          <Subtitle>
            {t("needsProtection")} <br /> {t("doBoth")}
          </Subtitle>
          <div>
            <a href="#statements">
              <ArrowDropDownCircleIcon fontSize="large" />
            </a>
          </div>
        </DivContainer>
      </Grid>
      <Grid item xs={12} xl={12}>
        <DivChildContainer id="statements">
          {getStatements().map(({ title, content, image }, index) => (
            <DivContent key={`statement_${index}`}>
              <div>
                <Image src={image} alt="tldr" />
              </div>
              <div>
                <DivTitle>{t(title)}</DivTitle>
                <div>{t(content)}</div>
              </div>
            </DivContent>
          ))}
        </DivChildContainer>
      </Grid>
    </Grid>
  );
};

function getStatements() {
  return [
    {
      title: "weDontStoreTitle",
      content: "weDontStoreDesc",
      image: Images.PantherImage,
    },
    {
      title: "weDontSellTitle",
      content: "weDontSellDesc",
      image: Images.TreesImage,
    },
    {
      title: "encryptedSearchesTitle",
      content: "encryptedSearchesDesc",
      image: Images.CrowImage,
    },
    {
      title: "trackingToolsTitle",
      content: "trackingToolsDesc",
      image: Images.FishImage,
    },
    {
      title: "turnOffTitle",
      content: "turnOffDesc",
      image: Images.FoxImage,
    },
  ];
}

// Styled Components

const DivContainer = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;
  height: 50vh;

  background-color: ${AppColor.AliceBlue};
`;

const DivChildContainer = styled.div`
  display: grid;
  grid-template-columns: auto;
  justify-content: center;
`;

const AboveTitle = styled.div`
  font-size: 1.5em;
  color: ${AppColor.Teal};
  text-transform: uppercase;
  padding: 10px 0px;
`;

const Subtitle = styled.div`
  font-size: 2em;
  text-align: center;
`;

const DivContent = styled.div`
  text-align: center;
  padding: 3% 15%;
`;

const DivTitle = styled.div`
  text-transform: capitalize;
  font-size: larger;
  padding-bottom: 10px;
`;

// translations

const translations = {
  [Language.English]: {
    weProtectYourPrivacy: "We protect your privacy",
    needsProtection: "Forests need protecting and so does your privacy.",
    doBoth: "We make sure to do both.",
    weDontStoreTitle: "We don’t store your searches permanently",
    weDontStoreDesc:
      "We don’t create personal profiles of you based on your search history. We actually anonymize all searches within one week.",
    weDontSellTitle: "We don’t sell your data to advertisers",
    weDontSellDesc:
      "Many web services collect user data in order to sell it without asking your permission. We don’t sell your data or your searches to advertising companies.",
    encryptedSearchesTitle: "Your searches are encrypted",
    encryptedSearchesDesc:
      "We protect your searches from potential eavesdroppers with a securely encrypted connection. This way we make sure that nobody between you and us can see your searches.",
    trackingToolsTitle: "We don’t use external tracking tools",
    trackingToolsDesc:
      "Most websites use external tracking tools, like Google Analytics, to optimize their services. We don’t use such third party trackers, in order to prevent others from accessing your searches.",
    turnOffTitle: "You can turn off all our tracking",
    turnOffDesc:
      "We only collect a small amount of data to be able to improve our services. If you want to opt out of tracking, you can activate “Do Not Track” in your browser’s settings.",
  },
  [Language.French]: {
    weProtectYourPrivacy: "Nous protégeons votre vie privée",
    needsProtection:
      "Les forêts ont besoin d'être protégées, tout comme votre vie privée.",
    doBoth: "Nous nous assurons de faire les deux.",
    weDontStoreTitle:
      "Nous ne stockons pas vos recherches de manière permanente",
    weDontStoreDesc:
      "Nous ne créons pas de profils personnels de vous en fonction de votre historique de recherche. En fait, nous anonymisons toutes les recherches en une semaine.",
    weDontSellTitle: "Nous ne vendons pas vos données à des annonceurs",
    weDontSellDesc:
      "De nombreux services Web collectent des données utilisateur afin de les vendre sans vous demander la permission. Nous ne vendons pas vos données ou vos recherches à des agences de publicité.",
    encryptedSearchesTitle: "Vos recherches sont cryptées",
    encryptedSearchesDesc:
      "Nous protégeons vos recherches contre les écoutes potentielles grâce à une connexion cryptée en toute sécurité. De cette façon, nous nous assurons que personne entre vous et nous ne peut voir vos recherches.",
    trackingToolsTitle: "Nous n'utilisons pas d'outils de suivi externes",
    trackingToolsDesc:
      "La plupart des sites Web utilisent des outils de suivi externes, comme Google Analytics, pour optimiser leurs services. Nous n'utilisons pas de tels trackers tiers, afin d'empêcher d'autres personnes d'accéder à vos recherches.",
    turnOffTitle: "Vous pouvez désactiver tous nos suivis",
    turnOffDesc:
      "Nous ne collectons qu'une petite quantité de données pour pouvoir améliorer nos services. Si vous souhaitez désactiver le suivi, vous pouvez activer « Ne pas suivre » dans les paramètres de votre navigateur.",
  },
};

export default withTranslations(translations)(Component);
