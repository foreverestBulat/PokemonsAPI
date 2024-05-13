<script setup>
    import Move from './Move.vue';
</script>

<template>
    <div class="Moves child">
        <h1>Moves</h1>
        <div class="list-moves">
            <Move v-for="move in moves" :moveObject="move"/>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            moves: {
                type: Array,
                default: []
            }
        },
    }
</script>