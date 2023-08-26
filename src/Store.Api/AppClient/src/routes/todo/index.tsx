import { $, component$, useStore } from "@builder.io/qwik";

export default component$(() => {
    const store = useStore({
        nested: {
            fields: { are: "also tracked" },
        },
        list: ["Item 1"],
    });
    const AddList = $(() => {
        const newList = [...store.list, `Item ${store.list.length + 1}`];
        store.list = newList;
    });

    return (
        <>
            <p>{store.nested.fields.are}</p>
            <button
                onClick$={() => {
                    if (store.nested.fields.are === "tracked") {
                        store.nested.fields.are = "not tracked";
                    } else {
                        store.nested.fields.are = "tracked";
                    }
                }}
            >
                Clicking me works because store is deep watched
            </button>
            <br />
            <button onClick$={AddList}>Add to List</button>
            <ul>
                {store.list.map((item, index) => (
                    <li key={index}>{item}</li>
                ))}
            </ul>
        </>
    );
});
