import { withLanguageControls } from "../../helpers";
import AboutUsComponent from "./about-us-component";
import * as Components from "./components";

export default function Index() {
  return <div></div>;
}

export const BannerComponent = withLanguageControls(Components.BannerComponent);

export const ContactUsComponent = withLanguageControls(
  Components.ContactUsComponent
);

export const HireComponent = withLanguageControls(Components.HireComponent);

export const MeetTheTeamComponent = withLanguageControls(
  Components.MeetTheTeamComponent
);

export const SocialBusinessComponent = withLanguageControls(
  Components.SocialBusinessComponent
);

export const AboutUsPage = withLanguageControls(AboutUsComponent);
