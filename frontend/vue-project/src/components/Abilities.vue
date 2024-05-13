<template>
    <div class="Abilities child">
        <h1>Abilities</h1>
        <div>
            <div class="list-abilities">
                <div v-for="name in abilities" class="ability" :style="{backgroundColor: '#C0C0C0'}">
                    {{ name }}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            abilities: {
                type: Array,
                default: []
            }
        }
    }
</script>