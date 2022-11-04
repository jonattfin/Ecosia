import { FormControl, OutlinedInput, Stack } from "@mui/material";
import { Search as SearchIcon } from "@mui/icons-material";
import { useEffect, useState, Fragment } from "react";
import Image from "next/image";
import Link from "next/link";
import styled from "@emotion/styled";

import * as Images from "./images";

export interface SearchProps {
  query: string;
  doSearch: (query: string) => void;
}

export default function Component(props: SearchProps) {
  const [query, setQuery] = useState(props.query);

  useEffect(() => props.doSearch(query), [query]);

  return (
    <MainSection>
      <Stack direction="row" spacing={2}>
        <Link href="/">
          <a>
            <ExtraDiv />
            <Image
              src={Images.LogoImage}
              alt="logo"
              width={"75px"}
              height={"60px"}
            />
          </a>
        </Link>
        <ExtraPadding>
          <FormControl size="small" variant="outlined">
            <OutlinedInput
              value={query}
              onChange={(ev) => {
                setQuery(ev.target.value);
              }}
              endAdornment={<SearchIcon />}
            />
          </FormControl>
        </ExtraPadding>
      </Stack>
    </MainSection>
  );
}

const MainSection = styled.section`
  padding-top: 60px;
`;

const ExtraPadding = styled.div`
  padding-top: 30px;
`;

const ExtraDiv = styled.div`
  padding: 5px;
`;
