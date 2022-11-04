import HowItWorksPage from "./how-it-works-component";
import { withLanguageControls } from "../../helpers";
import * as Components from "./components";

export default function Index() {
  return <div></div>;
}

export const BrandsComponent = withLanguageControls(Components.BrandsComponent);

export const GraphicsComponent = withLanguageControls(
  Components.GraphicsComponent
);

export const HowItWorksComponent = withLanguageControls(
  Components.HowItWorksComponent
);

export const PlantTreesComponent = withLanguageControls(
  Components.PlantTreesComponent
);

export const ReportsComponent = withLanguageControls(
  Components.ReportsComponent
);

export const HowItWorksPageIndex = withLanguageControls(HowItWorksPage);
