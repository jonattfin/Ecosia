import styled from "@emotion/styled";
import { ITranslationFunc, withTranslations } from "../../../helpers";
import { Language } from "../../../providers/context";

import { MainTitleDiv } from "../../../shared-components";

const Component = ({ t }: { t: ITranslationFunc }) => {
  return (
    <section>
      <ParentDiv>
        <MainTitleDiv>{t("ecosiaDescription")}</MainTitleDiv>
        <ChildDiv>
          {getTimePeriods().map((period, index) => (
            <div key={`period_${index}`}>
              <TitleDiv>{period.time}</TitleDiv>
              <ContentDiv>{period.title}</ContentDiv>
              <LineDiv />
              <ContentDiv>{t(period.content)}</ContentDiv>
            </div>
          ))}
        </ChildDiv>
        <div />
      </ParentDiv>
    </section>
  );
};

function getTimePeriods() {
  return [
    {
      time: "December 2009",
      title: "ecosia is born",
      content: "ecosiaIsBornContent",
    },
    {
      time: "2009 - 2011",
      title: "People's choice",
      content: "peopleChoiceContent",
    },
    {
      time: "April 2014",
      title: "First German B Corp",
      content: "firstGermanBContent",
    },
    {
      time: "April 2018",
      title: "25 million trees",
      content: "plantingMilestoneContent",
    },
  ];
}

// Styled Components

const ParentDiv = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const ChildDiv = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  height: 40vh;
`;

const TitleDiv = styled.div`
  text-transform: uppercase;
  padding: 15px 0;
  text-align: center;
`;

const LineDiv = styled.div`
  border: 3px solid #aab74f;
  margin: 10px 50px;
`;

const ContentDiv = styled.div`
  text-align: center;
`;

// translations

const translations = {
  [Language.English]: {
    ecosiaDescription:
      "Ecosia is a social business founded in 2009 after a trip around the world",
    ecosiaIsBornContent:
      "Christian founded Ecosia.org after a trip around the world helped him understand the problems of deforestation.",
    peopleChoiceContent:
      "ecosia won several awards for its clever concept and speedy growth in Europe and beyond.",
    firstGermanBContent:
      "Ecosia was the first German company to become a B Corporation thanks to its social business model.",
    plantingMilestoneContent:
      "A planting milestone! That same year, Ecosia also builds its own solar energy plant to power every search.",
  },
  [Language.French]: {
    ecosiaDescription:
      "Ecosia est une entreprise sociale fondée en 2009 après un voyage autour du monde",
    ecosiaIsBornContent:
      "Christian a fondé Ecosia.org après un voyage autour du monde qui l'a aidé à comprendre les problèmes de la déforestation.",
    peopleChoiceContent:
      "Ecosia a remporté plusieurs prix pour son concept intelligent et sa croissance rapide en Europe et au-delà.",
    firstGermanBContent:
      "Ecosia a été la première entreprise allemande à devenir une B Corporation grâce à son modèle d'entreprise sociale.",
    plantingMilestoneContent:
      "Une étape importante dans la plantation! La même année, Ecosia construit également sa propre centrale solaire pour alimenter toutes les recherches.",
  },
};

export default withTranslations(translations)(Component);
