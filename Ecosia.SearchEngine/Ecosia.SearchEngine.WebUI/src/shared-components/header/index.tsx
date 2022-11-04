import { Fragment, useContext } from "react";
import { LanguageContext } from "../../providers/context";

import HeaderComponent from "./header-component";

export default function Component(props: any) {
  const language = useContext(LanguageContext);
  return (
    <Fragment>
      <HeaderComponent {...{ language, ...props }} />
    </Fragment>
  );
}
