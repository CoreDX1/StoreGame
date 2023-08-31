import { component$ } from "@builder.io/qwik";
import { Link } from "@builder.io/qwik-city";

export default component$((props: { text: string; href: string }) => {
    return (
        <li>
            <Link href={props.href}>{props.text}</Link>
        </li>
    );
});
