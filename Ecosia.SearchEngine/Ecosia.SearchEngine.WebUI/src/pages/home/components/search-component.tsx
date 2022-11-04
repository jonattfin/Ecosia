import {
  FormControl,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  OutlinedInput,
} from "@mui/material";
import { Search as SearchIcon } from "@mui/icons-material";
import { useState, Fragment, useEffect } from "react";
import styled from "@emotion/styled";

import * as Images from "./images";
import { Image, AppColor } from "../../../shared-components";
import { Language } from "../../../providers/context";
import { ITranslationFunc, withTranslations } from "../../../helpers";
import { ResultQuery } from "../../../api/interfaces";

export interface SearchComponentProps {
  onSearch: (query: string) => void;
  onSearchValueSelected: (query: string) => void;
  q: string;
  counter: number;
  language?: Language;
  t: ITranslationFunc;
  data: ResultQuery[];
}

const Component = ({
  onSearch,
  onSearchValueSelected,
  q,
  counter,
  t,
  data,
}: SearchComponentProps) => {
  const [query, setQuery] = useState(q || "");

  const imageProps = getImageProps(50);

  const handleChange = (ev: any) => setQuery(ev.target.value);

  useEffect(() => onSearch(query), [query]);

  return (
    <MainSection>
      <div>
        <LogoImage src={Images.LogoImage} alt="logo" {...imageProps} />
      </div>
      <div>
        <FormControl fullWidth>
          <SearchFormControl variant="outlined" fullWidth>
            <OutlinedInput
              value={query}
              placeholder={t("searchTheWeb")}
              onChange={handleChange}
              inputProps={{ "data-test": "searchInput" }}
              endAdornment={<SearchIcon />}
            />
          </SearchFormControl>
          {query && (
            <SearchList data-test="searchList">
              {data.map((item, index) => (
                <ListItem key={`d_${index}`} disablePadding>
                  <ListItemButton
                    onClick={() => onSearchValueSelected(item.snippet)}
                  >
                    <ListItemText primary={item.snippet} />
                  </ListItemButton>
                </ListItem>
              ))}
            </SearchList>
          )}
        </FormControl>
      </div>
      {!query && (
        <Fragment>
          <div>
            <h1>{t("searchEngine")}</h1>
          </div>
          <CounterTextDiv>{counter.toLocaleString()}</CounterTextDiv>
          <div>{t("numberOfTrees")}</div>
        </Fragment>
      )}
    </MainSection>
  );
};

function getImageProps(percentage: number = 100) {
  const scale = percentage / 100;
  return { width: 298 * scale, height: 214 * scale };
}

// Styled Components

const MainSection = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

  height: 100vh;
`;

const LogoImage = styled(Image)`
  padding: 20px;
`;

const SearchFormControl = styled(FormControl)`
  width: 25vw;

  @media (max-width: 1080px) {
    width: 75vw;
  }
`;

const CounterTextDiv = styled.div`
  font-size: 4vh;
  color: ${AppColor.Teal};
`;

const SearchList = styled(List)`
  height: 300px;
  overflow: auto;
`;

// translations

const translations = {
  [Language.English]: {
    searchTheWeb: "Search the web to plant trees...",
    searchEngine: "The search engine that plants trees.",
    numberOfTrees: "Trees planted by Ecosia users.",
  },
  [Language.French]: {
    searchTheWeb: "Rechercher sur le Web pour planter des arbres...",
    searchEngine: "Le moteur de recherche qui plante des arbres.",
    numberOfTrees: "Arbres plantés par les utilisateurs d'Ecosia",
  },
};

export default withTranslations(translations)(Component);
