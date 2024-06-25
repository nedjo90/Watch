import styled from 'styled-components';
import {Link} from 'react-router-dom';
import {
    HOVER_TEXT,
    PRIMARY_BACKGROUND_COLOR,
    PRIMARY_TEXT_HOVER_COLOR,
    SECONDARY_BACKGROUND_COLOR
} from './style-constant.js';



export const NavBar = styled.nav`
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    height: 4rem;
    padding: 0.5rem 1rem;
`;

export const HomeLogo = styled.svg`
    height: 1.5rem;
    width: 2rem;
    fill: ${SECONDARY_BACKGROUND_COLOR};
    &:hover{
        fill: ${PRIMARY_TEXT_HOVER_COLOR}
    }
`

export const MyLink = styled(Link)`
    &:hover {
        ${() => ({...HOVER_TEXT})}
    }
    padding: 1em;
    text-decoration: none;
    color: ${SECONDARY_BACKGROUND_COLOR};
`

export const NavBarLinks = styled.div`
`
